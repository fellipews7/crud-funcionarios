
import { CargoDetailFormComponent } from './cargo/cargo-detail-form/cargo-detail-form.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { FuncionarioFormComponent } from './funcionario/funcionario-form/funcionario-form.component';
import { CargoComponent } from './cargo/cargo.component';
import { CargoFormComponent } from './cargo/cargo-form/cargo-form.component';

const routes: Routes = [
  { path: 'funcionario', component: FuncionarioComponent },
  { path: 'funcionario/novo', component: FuncionarioFormComponent },
  { path: 'funcionario/:id', component: FuncionarioFormComponent },
  { path: 'cargo', component: CargoComponent },
  { path: 'cargo/novo', component: CargoFormComponent },
  { path: 'cargo/:id', component: CargoDetailFormComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
