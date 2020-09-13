import { Component, OnInit, SimpleChanges } from '@angular/core';

import { MessageService, ConfirmationService } from 'primeng/api';
import { QuadroService } from '../../../Services/quadro.service';

import { Quadro } from '../../../Models/quadro';

@Component({
  selector: 'app-quadros',
  templateUrl: './quadros.component.html',
  styleUrls: ['./quadros.component.css']
})
export class QuadrosComponent implements OnInit {

  view: string = "browse";
  quadro: Quadro;

  quadros: Quadro[];
  viewAtualizar: boolean = false;

  private clonedQuadros: Quadro[] = [];

  constructor(private quadroService: QuadroService, private messageService: MessageService,
    private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.atualizar();

    this.quadro = new Quadro();
  }

  atualizar(): void {
    this.viewAtualizar = true;
    this.quadroService.listar().subscribe(quadros => {
      this.quadros = quadros;
      this.viewAtualizar = false;
    });
  }

  desistir(): void {
    this.view = "browse";
  }

  gravar(): void {
    this.quadroService.inserir(this.quadro).subscribe(q => {
      this.quadros.push(q);
      this.sortQuadros();
      this.desistir();
    });
  }

  inserir(): void {
    this.view = "insert";
    this.quadro = new Quadro();
  }

  onRowEditInit(quadro: Quadro) {
    this.clonedQuadros.push(this.clone(quadro));
  }

  onRowEditSave(quadro: Quadro, index: number) {
    this.quadroService.alterar(quadro).subscribe(q => {
      this.quadros[index] = q;
      this.clonedQuadros = this.clonedQuadros.filter(q => q.IdQuadro != quadro.IdQuadro);
      this.sortQuadros();
    });
  }

  onRowEditDelete(quadro: Quadro) {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão?',
      rejectLabel: "Não",
      acceptLabel: "Sim",
      accept: () => {
        this.quadroService.excluir(quadro.IdQuadro).subscribe(() => {
          this.quadros = this.quadros.filter(q => q.IdQuadro != quadro.IdQuadro);
          this.clonedQuadros = this.clonedQuadros.filter(q => q.IdQuadro != quadro.IdQuadro);
        });
      }
    });
  }

  onRowEditCancel(quadro: Quadro, index: number) {
    this.quadros[index] = this.clonedQuadros.find(q => q.IdQuadro == quadro.IdQuadro);
    this.clonedQuadros = this.clonedQuadros.filter(q => q.IdQuadro != quadro.IdQuadro);
  }

  private clone(quadro: Quadro): Quadro {
    var q: Quadro = new Quadro();
    q.IdQuadro = quadro.IdQuadro;
    q.Descricao = quadro.Descricao;
    return q;
  }

  private sortQuadros():void {
    this.quadros = this.quadros.sort((a, b) => {
      if (a.Descricao >= b.Descricao) {
        return 1;
      }

      if (a.Descricao < b.Descricao) {
        return -1;
      }

      return 0;
    });
  }

}
