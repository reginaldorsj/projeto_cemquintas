import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PrimeNGModule } from '../../prime-ng.module';
import { ComponentsModule } from '../../Components/components.module';

import { QuadrosComponent } from './quadros/quadros.component';
import { QuadrasComponent } from './quadras/quadras.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { CartoriosComponent } from './cartorios/cartorios.component';
import { FunerariasComponent } from './funerarias/funerarias.component';


@NgModule({
  declarations: [
    QuadrosComponent,
    QuadrasComponent,
    UsuariosComponent,
    CartoriosComponent,
    FunerariasComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    PrimeNGModule,
    ComponentsModule
  ],
  exports: [
  ],
  providers: [
  ]
})
export class CadastrosModule { }
