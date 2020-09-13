import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-botoes-sepultamento',
  templateUrl: './botoes-sepultamento.component.html',
  styleUrls: ['./botoes-sepultamento.component.css']
})
export class BotoesSepultamentoComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  inserir(): void {
    this.router.navigate(['/sepultamento/inserir']);

  }

  localizar(): void {
    this.router.navigate(['/sepultamento/localizar']);
  }
}
