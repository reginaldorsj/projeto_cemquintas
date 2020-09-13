import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PrimeNGModule } from '../../prime-ng.module';
import { ComponentsModule } from '../../Components/components.module';

import { InfiniteScrollModule } from 'ngx-infinite-scroll';

import { BotoesSepultamentoComponent } from './botoes-sepultamento/botoes-sepultamento.component';
import { InserirSepultamentoComponent } from './inserir-sepultamento/inserir-sepultamento.component';
import { LocalizarSepultamentoComponent } from './localizar-sepultamento/localizar-sepultamento.component';
import { ImpressaoTermoCompromissoComponent } from './impressao-termo-compromisso/impressao-termo-compromisso.component';
import { ImpressaoSepultamentoComponent } from './impressao-sepultamento/impressao-sepultamento.component';
import { ExumacaoComponent } from './exumacao/exumacao.component';
import { ImpressaoExumacaoComponent } from './impressao-exumacao/impressao-exumacao.component';

@NgModule({
  declarations: [
    BotoesSepultamentoComponent,
    InserirSepultamentoComponent,
    LocalizarSepultamentoComponent,
    ImpressaoTermoCompromissoComponent,
    ImpressaoSepultamentoComponent,
    ExumacaoComponent,
    ImpressaoExumacaoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    PrimeNGModule,
    ComponentsModule,
    InfiniteScrollModule
  ]
})
export class SepultamentoModule { }
