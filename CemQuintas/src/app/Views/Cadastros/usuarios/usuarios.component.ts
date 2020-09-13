import { Component, OnInit} from '@angular/core';

import { MessageService, ConfirmationService } from 'primeng/api';
import { UsuarioService } from '../../../Services/usuario.service';
import { PerfilService } from '../../../Services/perfil.service';

import { Usuario } from '../../../Models/usuario';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  confirmaSenha: string;

  view: string = "browse";
  usuario: Usuario;

  usuarios: Usuario[];
  perfis = [];

  viewAtualizar: boolean = false;

  constructor(private usuarioService: UsuarioService, private messageService: MessageService,
    private perfilService: PerfilService, private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.perfilService.listar().subscribe(perfis => {
      perfis.forEach((perfil) => {
        this.perfis.push({ "label": perfil.Descricao, "value": perfil })
      })
    });

    this.atualizar();

    this.usuario = new Usuario();
  }

  atualizar(): void {
    this.viewAtualizar = true;
    this.usuarioService.listar().subscribe(usuarios => {
      this.usuarios = usuarios;
      this.viewAtualizar = false;
    });
  }

  desistir(): void {
    this.view = "browse";

    this.atualizar();
  }

  inserir(): void {
    this.view = "insert";
    this.usuario = new Usuario();
    this.confirmaSenha = undefined;
  }

  gravar(): void {
    if (!this.usuario.IdUsuario) {
      this.usuarioService.inserir(this.usuario).subscribe(usuario => {
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Inclusão realizada com sucesso.' });
        this.atualizar();
        this.desistir();
      });
    } else {
      this.usuarioService.alterar(this.usuario).subscribe(usuario => {
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Alteração realizada com sucesso.' });
        this.atualizar();
        this.desistir();
      });
    }
  }

  excluir(usuario: Usuario) {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão?',
      rejectLabel: "Não",
      acceptLabel: "Sim",
      accept: () => {
        this.usuarioService.excluir(usuario.IdUsuario).subscribe(() => {
          this.atualizar();
        });
      }
    });
  }
  alterar(usuario: Usuario) {
    this.view = "insert";
    this.usuario = usuario;
    this.confirmaSenha = usuario.Senha;
  }
}
