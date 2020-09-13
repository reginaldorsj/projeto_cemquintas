import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ExumacaoService } from '../../../Services/exumacao.service';
import { Exumacao } from '../../../Models/exumacao';

@Component({
  selector: 'app-impressao-exumacao',
  templateUrl: './impressao-exumacao.component.html',
  styleUrls: ['./impressao-exumacao.component.css']
})
export class ImpressaoExumacaoComponent implements OnInit {

  idSepultamento: number;
  exumacao: Exumacao;

  constructor(private activatedRoute: ActivatedRoute, private exumacaoService: ExumacaoService,
    private router: Router) { }

  ngOnInit(): void {
    window.scroll(0, 0);

    this.idSepultamento = this.activatedRoute.snapshot.params['id'];
    if (this.idSepultamento) {
      this.exumacaoService.selecionarPorSepultamento(this.idSepultamento).subscribe((exumacao: Exumacao) => {
        if (!exumacao)
          this.router.navigate(['/sepultamento/page-not-found']);
        else {
          this.exumacao = exumacao;
        }
      });
    }
    else {
      this.router.navigate(['/sepultamento/inserir']);
    }
  }

  printDiv() {
    var divContents = document.getElementById("divExumacao").innerHTML;
    var a = window.open('', '', 'height=600, width=800');
    a.document.write('<html>');
    a.document.write('<body>');
    a.document.write(divContents);
    a.document.write('</body></html>');
    a.document.close();
    a.print();
  }

  voltar() {
    this.router.navigate([`/sepultamento/exumacao/${this.idSepultamento}`]);
  }
}
