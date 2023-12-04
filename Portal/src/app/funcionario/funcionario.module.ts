import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FuncionarioComponent } from './funcionario.component';
import { FuncionarioFormComponent } from './funcionario-form/funcionario-form.component';
import { FuncionarioDetailComponent } from './funcionario-detail/funcionario-detail.component';
import { FuncionarioDetailFormComponent } from './funcionario-detail-form/funcionario-detail-form.component';
import { FormDebugComponent } from '../form-debug/form-debug.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
        FuncionarioComponent,
        FuncionarioFormComponent,
        FuncionarioDetailComponent,
        FuncionarioDetailFormComponent,
        FormDebugComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule,
        HttpClientModule,
        BsDatepickerModule.forRoot()
    ],
    exports: [],
    providers: [],
})
export class FuncionarioModule { }