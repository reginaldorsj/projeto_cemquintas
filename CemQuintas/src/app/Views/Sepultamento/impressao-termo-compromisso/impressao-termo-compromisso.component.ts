import { Component, OnInit, Input } from '@angular/core';

import { Sepultamento } from '../../../Models/sepultamento';
import { ActivatedRoute, Router } from '@angular/router';
import { SepultamentoService } from '../../../Services/sepultamento.service';
import { Responsavel } from '../../../Models/responsavel';
import { Testemunha } from '../../../Models/testemunha';

@Component({
  selector: 'app-impressao-termo-compromisso',
  templateUrl: './impressao-termo-compromisso.component.html',
  styleUrls: ['./impressao-termo-compromisso.component.css']
})
export class ImpressaoTermoCompromissoComponent implements OnInit {

  id: number;
  sepultamento: Sepultamento;

  constructor(private activatedRoute: ActivatedRoute, private sepultamentoService: SepultamentoService,
    private router: Router) { }

  ngOnInit(): void {
    window.scroll(0, 0);

    this.id = this.activatedRoute.snapshot.params['id'];
    if (this.id) {
      this.sepultamentoService.selecionarPorId(this.id).subscribe((sepultamento: Sepultamento) => {
        if (!sepultamento || sepultamento.Documento.IdDocumento != 1)
          this.router.navigate(['/sepultamento/page-not-found']);
        else {
          this.sepultamento = sepultamento;
        }
      });
    }
    else {
      this.router.navigate(['/sepultamento/inserir']);
    }
  }

  printDiv() {
    var divContents = document.getElementById("divTermo").innerHTML;
    var a = window.open('', '', 'height=600, width=800');
    a.document.write('<html>');
    a.document.write('<body>');
    a.document.write(divContents);
    a.document.write('</body></html>');
    a.document.close();
    a.print();
  }

  voltar() {
    this.router.navigate([`/sepultamento/inserir/${this.id}`]);
  }
}
