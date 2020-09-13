import { Component, OnInit } from '@angular/core';
import { Sepultamento } from '../../../Models/sepultamento';
import { Router, ActivatedRoute } from '@angular/router';

import { SepultamentoService } from '../../../Services/sepultamento.service';

@Component({
  selector: 'app-impressao-sepultamento',
  templateUrl: './impressao-sepultamento.component.html',
  styleUrls: ['./impressao-sepultamento.component.css']
})
export class ImpressaoSepultamentoComponent implements OnInit {

  data: Date = new Date();

  id: number;
  sepultamento: Sepultamento;

  constructor(private activatedRoute: ActivatedRoute, private sepultamentoService: SepultamentoService,
    private router: Router) { }

  ngOnInit(): void {
    window.scroll(0, 0);

    this.id = this.activatedRoute.snapshot.params['id'];
    if (this.id) {
      this.sepultamentoService.selecionarPorId(this.id).subscribe((sepultamento: Sepultamento) => {
        if (!sepultamento || sepultamento.Documento.IdDocumento != 2)
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
    var divContents = document.getElementById("divSepultamento").innerHTML;
    var a = window.open('', '', 'height=600, width=800');
    a.document.write('<html>');
    a.document.write('<body>');
    a.document.write(divContents);
    a.document.write('</body></html>');
    a.document.close();
    a.print();
  }

  voltar() {
    this.router.navigate([`/sepultamento/alterar/${this.id}`]);
  }
}
