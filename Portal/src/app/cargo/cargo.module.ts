import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { CargoComponent } from './cargo.component';
import { CargoFormComponent } from './cargo-form/cargo-form.component';
import { CargoDetailComponent } from './cargo-detail/cargo-detail.component';
import { CargoDetailFormComponent } from './cargo-detail-form/cargo-detail-form.component';
import { FormDebugComponent } from '../form-debug/form-debug.component';

@NgModule({
    declarations: [
        CargoComponent,
        CargoFormComponent,
        CargoDetailComponent,
        CargoDetailFormComponent,
        FormDebugComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule,
        BsDatepickerModule.forRoot()
    ],
    exports: [],
    providers: [],
})
export class CargoModule { }