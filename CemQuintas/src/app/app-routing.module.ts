import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './Shared/auth-guard';

import { NotFoundComponent } from './Views/not-found/not-found.component';
import { LoginComponent } from './Views/login/login.component';
import { QuadrosComponent } from './Views/Cadastros/quadros/quadros.component';
import { QuadrasComponent } from './Views/Cadastros/quadras/quadras.component';
import { UsuariosComponent } from './Views/Cadastros/usuarios/usuarios.component';
import { CartoriosComponent } from './Views/Cadastros/cartorios/cartorios.component';
import { AlterarSenhaComponent } from './Views/alterar-senha/alterar-senha.component';
import { MapaComponent } from './Views/Relatorios/mapa/mapa.component';
import { TermosVencidosComponent } from './Views/Relatorios/termos-vencidos/termos-vencidos.component';
import { ProdutividadeDigitadoresComponent } from './Views/Relatorios/produtividade-digitadores/produtividade-digitadores.component';
import { ListagemPeriodoComponent } from './Views/Relatorios/listagem-periodo/listagem-periodo.component';
import { ListagemFaixaComponent } from './Views/Relatorios/listagem-faixa/listagem-faixa.component';
import { FunerariasComponent } from './Views/Cadastros/funerarias/funerarias.component';
import { InserirSepultamentoComponent } from './Views/Sepultamento/inserir-sepultamento/inserir-sepultamento.component';
import { LocalizarSepultamentoComponent } from './Views/Sepultamento/localizar-sepultamento/localizar-sepultamento.component';
import { ImpressaoTermoCompromissoComponent } from './Views/Sepultamento/impressao-termo-compromisso/impressao-termo-compromisso.component';
import { ImpressaoSepultamentoComponent } from './Views/Sepultamento/impressao-sepultamento/impressao-sepultamento.component';
import { ExumacaoComponent } from './Views/Sepultamento/exumacao/exumacao.component';
import { ImpressaoExumacaoComponent } from './Views/Sepultamento/impressao-exumacao/impressao-exumacao.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'alterar-senha',
    component: AlterarSenhaComponent
  },
  {
    path: 'mapa',
    component: MapaComponent,
    canActivate: [AuthGuard]
  }, {
    path: 'sepultamento',
    children: [
      {
        path: '',
        redirectTo: '/page-not-found',
        pathMatch: 'full'
      },
      {
        path: 'inserir',
        component: InserirSepultamentoComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'alterar',
        children: [
          {
            path: '',
            redirectTo: '/page-not-found',
            pathMatch: 'full'
          },
          {
            path: ':id',
            component: InserirSepultamentoComponent,
            canActivate: [AuthGuard]
          }
        ]
      },
      {
        path: 'exumacao',
        children: [
          {
            path: '',
            component: InserirSepultamentoComponent,
            canActivate: [AuthGuard]
          },
          {
            path: ':id',
            component: ExumacaoComponent,
            canActivate: [AuthGuard]
          },
          {
            path: 'impressao',
            children: [
              {
                path: '',
                redirectTo: '/page-not-found',
                pathMatch: 'full'
              },
              {
                path: ':id',
                component: ImpressaoExumacaoComponent,
                canActivate: [AuthGuard]
              }
            ]
          }
        ]
      },
      {
        path: 'localizar',
        component: LocalizarSepultamentoComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'impressao-termo',
        children: [
          {
            path: '',
            redirectTo: '/page-not-found',
            pathMatch: 'full'
          },
          {
            path: ':id',
            component: ImpressaoTermoCompromissoComponent,
            canActivate: [AuthGuard]
          }
        ]
      },
      {
        path: 'impressao-sepultamento',
        children: [
          {
            path: '',
            redirectTo: '/page-not-found',
            pathMatch: 'full'
          },
          {
            path: ':id',
            component: ImpressaoSepultamentoComponent,
            canActivate: [AuthGuard]
          }
        ]
      }
    ]
  }, {
    path: 'relatorio',
    children: [
      {
        path: '',
        redirectTo: '/page-not-found',
        pathMatch: 'full'
      },
      {
        path: 'termos-vencidos',
        component: TermosVencidosComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'listagem-faixa',
        component: ListagemFaixaComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'produtividade-digitadores',
        component: ProdutividadeDigitadoresComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'listagem-periodo',
        component: ListagemPeriodoComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'mapa',
        component: MapaComponent,
        canActivate: [AuthGuard]
      }
    ]
  },
  {
    path: 'cadastro',
    children: [
      {
        path: '',
        redirectTo: '/page-not-found',
        pathMatch: 'full'
      },
      {
        path: 'funeraria',
        component: FunerariasComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'quadro',
        component: QuadrosComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'quadra',
        component: QuadrasComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'usuario',
        component: UsuariosComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'cartorio',
        component: CartoriosComponent,
        canActivate: [AuthGuard]
      }
    ]
  },
  {
    path: 'page-not-found',
    component: NotFoundComponent
  },
  {
    path: '**',
    redirectTo: '/page-not-found',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
