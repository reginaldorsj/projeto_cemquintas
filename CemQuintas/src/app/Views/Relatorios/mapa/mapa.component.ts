import { Component, OnInit } from '@angular/core';

import { SepultamentoService } from '../../../Services/sepultamento.service';

import { TotalAnual } from '../../../Models/total-anual';

@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrls: ['./mapa.component.css']
})
export class MapaComponent implements OnInit {

  viewAtualizar: boolean = true;
  mapa: TotalAnual[];
  totalMensal: TotalAnual[] = new Array(1);

  constructor(private sepultamentoService: SepultamentoService) { }

  ngOnInit(): void {
    this.totalMensal[0] = new TotalAnual();
    this.totalMensal[0].Jan = 0;
    this.totalMensal[0].Fev = 0;
    this.totalMensal[0].Mar = 0;
    this.totalMensal[0].Abr = 0;
    this.totalMensal[0].Mai = 0;
    this.totalMensal[0].Jun = 0;
    this.totalMensal[0].Jul = 0;
    this.totalMensal[0].Ago = 0;
    this.totalMensal[0].Set = 0;
    this.totalMensal[0].Out = 0;
    this.totalMensal[0].Nov = 0;
    this.totalMensal[0].Dez = 0;
    this.totalMensal[0].Total = 0;

    this.sepultamentoService.listarMapa().subscribe(mapa => {
      mapa.forEach(total => {
        this.totalMensal[0].Jan += total.Jan;
        this.totalMensal[0].Fev += total.Fev;
        this.totalMensal[0].Mar += total.Mar;
        this.totalMensal[0].Abr += total.Abr;
        this.totalMensal[0].Mai += total.Mai;
        this.totalMensal[0].Jun += total.Jun;
        this.totalMensal[0].Jul += total.Jul;
        this.totalMensal[0].Ago += total.Ago;
        this.totalMensal[0].Set += total.Set;
        this.totalMensal[0].Out += total.Out;
        this.totalMensal[0].Nov += total.Nov;
        this.totalMensal[0].Dez += total.Dez;
        this.totalMensal[0].Total += total.Total;
      })
      mapa.push(this.totalMensal[0]);
      this.mapa = mapa;

      this.viewAtualizar = false;
    });
  }
}
