import { Component, OnInit, SimpleChanges } from '@angular/core';

import { MessageService, ConfirmationService } from 'primeng/api';
import { QuadraService } from '../../../Services/quadra.service';

import { Quadra } from '../../../Models/quadra';

@Component({
  selector: 'app-quadras',
  templateUrl: './quadras.component.html',
  styleUrls: ['./quadras.component.css']
})
export class QuadrasComponent implements OnInit {

  view: string = "browse";
  quadra: Quadra;

  quadras: Quadra[];
  viewAtualizar: boolean = false;

  private clonedQuadras: Quadra[] = [];

  constructor(private quadraService: QuadraService, private messageService: MessageService,
    private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    this.atualizar();

    this.quadra = new Quadra();
  }

  atualizar(): void {
    this.viewAtualizar = true;
    this.quadraService.listar().subscribe(quadras => {
      this.quadras = quadras;
      this.viewAtualizar = false;
    });
  }

  desistir(): void {
    this.view = "browse";
  }

  gravar(): void {
    this.quadraService.inserir(this.quadra).subscribe(q => {
      this.quadras.push(q);
      this.sortQuadras();
      this.desistir();
    });
  }

  inserir(): void {
    this.view = "insert";
    this.quadra = new Quadra();
  }

  onRowEditInit(quadra: Quadra) {
    this.clonedQuadras.push(this.clone(quadra));
  }

  onRowEditSave(quadra: Quadra, index: number) {
    this.quadraService.alterar(quadra).subscribe(q => {
      this.quadras[index] = q;
      this.clonedQuadras = this.clonedQuadras.filter(q => q.IdQuadra != quadra.IdQuadra);
      this.sortQuadras();
    });
  }

  onRowEditDelete(quadra: Quadra) {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão?',
      rejectLabel: "Não",
      acceptLabel: "Sim",
      accept: () => {
        this.quadraService.excluir(quadra.IdQuadra).subscribe(() => {
          this.quadras = this.quadras.filter(q => q.IdQuadra != quadra.IdQuadra);
          this.clonedQuadras = this.clonedQuadras.filter(q => q.IdQuadra != quadra.IdQuadra);
        });
      }
    });
  }

  onRowEditCancel(quadra: Quadra, index: number) {
    this.quadras[index] = this.clonedQuadras.find(q => q.IdQuadra == quadra.IdQuadra);
    this.clonedQuadras = this.clonedQuadras.filter(q => q.IdQuadra != quadra.IdQuadra);
  }

  private clone(quadra: Quadra): Quadra {
    var q: Quadra = new Quadra();
    q.IdQuadra = quadra.IdQuadra;
    q.Descricao = quadra.Descricao;
    return q;
  }

  private sortQuadras():void {
    this.quadras = this.quadras.sort((a, b) => {
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
