import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PrimeNGModule } from '../../prime-ng.module';
import { ComponentsModule } from '../../Components/components.module';

import { MapaComponent } from './mapa/mapa.component';
import { TermosVencidosComponent } from './termos-vencidos/termos-vencidos.component';
import { ProdutividadeDigitadoresComponent } from './produtividade-digitadores/produtividade-digitadores.component';
import { ListagemPeriodoComponent } from './listagem-periodo/listagem-periodo.component';
import { ListagemFaixaComponent } from './listagem-faixa/listagem-faixa.component';


@NgModule({
  declarations: [
    MapaComponent,
    TermosVencidosComponent,
    ProdutividadeDigitadoresComponent,
    ListagemPeriodoComponent,
    ListagemFaixaComponent
  ],
  imports: [
    CommonModule,
    PrimeNGModule,
    FormsModule,
    ComponentsModule
  ],
  providers: [
  ]
})
export class RelatoriosModule { }
