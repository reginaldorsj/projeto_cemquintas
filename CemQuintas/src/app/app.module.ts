import { NgModule, LOCALE_ID } from '@angular/core';
import { registerLocaleData, DatePipe, CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import localePt from '@angular/common/locales/pt';
import { AppRoutingModule } from './app-routing.module';

import { AuthGuard } from './Shared/auth-guard';
import { AuthService } from './Shared/auth.service';
import { TokenizedInterceptor } from './Shared/tokenized-interceptor';
import { MessageService, ConfirmationService } from 'primeng/api';

import { CadastrosModule } from './Views/Cadastros/cadastros.module';
import { RelatoriosModule } from './Views/Relatorios/relatorios.module';
import { PrimeNGModule } from './prime-ng.module';
import { ComponentsModule } from './Components/components.module';
import { SepultamentoModule } from './Views/Sepultamento/sepultamento.module';

import { AppComponent } from './app.component';
import { NotFoundComponent } from './Views/not-found/not-found.component';
import { LoginComponent } from './Views/login/login.component';
import { AlterarSenhaComponent } from './Views/alterar-senha/alterar-senha.component';

registerLocaleData(localePt);


@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    LoginComponent,
    AlterarSenhaComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    CadastrosModule,
    RelatoriosModule,
    PrimeNGModule,
    ComponentsModule,
    SepultamentoModule
  ],
  exports: [
  ],
  providers: [
    ConfirmationService,
    MessageService,
    DatePipe,
    AuthGuard,
    AuthService,
    {
      provide: LOCALE_ID,
      useValue: 'pt-BR'
    }, {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenizedInterceptor,
      multi: true,
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
