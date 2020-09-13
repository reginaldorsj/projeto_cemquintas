import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../..//Shared/auth.service';
import { LoggedinUser } from '../../Shared/loggedin-user';
import { AppResponse } from '../../Shared/app-response';

import { MessageService } from 'primeng/api';
import { SepultamentoService } from '../../Services/sepultamento.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;
  error: string;
  viewProgress: boolean;

  constructor(private authService: AuthService, private router: Router, private messageService: MessageService,
    private sepultamentoService: SepultamentoService) { }

  ngOnInit(): void {
    this.viewProgress = false;
    this.authService.logout();
  }

  entrar(): void {
    this.error = null;
    this.viewProgress = true;
    this.authService.login(this.username, this.password)
      .subscribe((data: LoggedinUser) => {
        this.authService.manageSession(data);
        this.authService.loginStatus.emit(true);

        if (this.authService.redirectUrl && !this.authService.redirectUrl.toLowerCase().endsWith('/login')) {
          this.router.navigate([this.authService.redirectUrl]);
        } else {
          let now: Date = new Date();
          this.sepultamentoService.listarTermosDataLimite(now, now).subscribe(sepultamentos => {
            if (sepultamentos.length != 0)
              this.router.navigateByUrl('/relatorio/termos-vencidos?op=listar');
            else
              this.router.navigate(['/sepultamento/inserir']);
          });
        }
      }, (error: AppResponse) => {
        this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro', detail: error.message });
        this.viewProgress = false;
      });
  }
}
