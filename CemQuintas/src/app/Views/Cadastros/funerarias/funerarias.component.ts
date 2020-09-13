import { Component, OnInit, SimpleChanges } from '@angular/core';

import { MessageService, ConfirmationService } from 'primeng/api';
import { FunerariaService } from '../../../Services/funeraria.service';

import { Funeraria } from '../../../Models/funeraria';

@Component({
  selector: 'app-funerarias',
  templateUrl: './funerarias.component.html',
  styleUrls: ['./funerarias.component.css']
})
export class FunerariasComponent implements OnInit {

  view: string = "browse";
  funeraria: Funeraria;

  funerarias: Funeraria[];
  viewAtualizar: boolean = false;

  private clonedFunerarias: Funeraria[] = [];

  constructor(private funerariaService: FunerariaService, private messageService: MessageService,
    private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.atualizar();

    this.funeraria = new Funeraria();
  }

  atualizar(): void {
    this.viewAtualizar = true;
    this.funerariaService.listar().subscribe(funerarias => {
      this.funerarias = funerarias;
      this.viewAtualizar = false;
    });
  }

  desistir(): void {
    this.view = "browse";
  }

  gravar(): void {
    this.funerariaService.inserir(this.funeraria).subscribe(q => {
      this.funerarias.push(q);
      this.sortFunerarias();
      this.desistir();
    });
  }

  inserir(): void {
    this.view = "insert";
    this.funeraria = new Funeraria();
  }

  onRowEditInit(funeraria: Funeraria) {
    this.clonedFunerarias.push(this.clone(funeraria));
  }

  onRowEditSave(funeraria: Funeraria, index: number) {
    this.funerariaService.alterar(funeraria).subscribe(q => {
      this.funerarias[index] = q;
      this.clonedFunerarias = this.clonedFunerarias.filter(q => q.IdFuneraria != funeraria.IdFuneraria);
      this.sortFunerarias();
    });
  }

  onRowEditDelete(funeraria: Funeraria) {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão?',
      rejectLabel: "Não",
      acceptLabel: "Sim",
      accept: () => {
        this.funerariaService.excluir(funeraria.IdFuneraria).subscribe(() => {
          this.funerarias = this.funerarias.filter(q => q.IdFuneraria != funeraria.IdFuneraria);
          this.clonedFunerarias = this.clonedFunerarias.filter(q => q.IdFuneraria != funeraria.IdFuneraria);
        });
      }
    });
  }

  onRowEditCancel(funeraria: Funeraria, index: number) {
    this.funerarias[index] = this.clonedFunerarias.find(q => q.IdFuneraria == funeraria.IdFuneraria);
    this.clonedFunerarias = this.clonedFunerarias.filter(q => q.IdFuneraria != funeraria.IdFuneraria);
  }

  private clone(funeraria: Funeraria): Funeraria {
    var q: Funeraria = new Funeraria();
    q.IdFuneraria = funeraria.IdFuneraria;
    q.Nome = funeraria.Nome;
    return q;
  }

  private sortFunerarias(): void {
    this.funerarias = this.funerarias.sort((a, b) => {
      if (a.Nome >= b.Nome) {
        return 1;
      }

      if (a.Nome < b.Nome) {
        return -1;
      }

      return 0;
    });
  }
}
