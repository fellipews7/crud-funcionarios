import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { Http, HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BsDropdownModule } from 'ngx-bootstrap';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FuncionarioComponent } from './funcionario/funcionario.component';
import { HomeComponent } from './home/home.component';
import { FuncionarioFormComponent } from './funcionario/funcionario-form/funcionario-form.component';
import { FuncionarioService } from './funcionario/services/funcionario.service';
import { CargoModule } from './cargo/cargo.module';
import { CargoService } from './cargo/services/cargo.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    FuncionarioComponent,
    HomeComponent,
    FuncionarioFormComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    CargoModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [FuncionarioService, CargoService],
  bootstrap: [AppComponent],
})
export class AppModule {}
