import { Component, OnInit } from '@angular/core';

import { FuncionarioFormService } from '../services/funcionario-form.service';

@Component({
  selector: 'app-funcionario-detail-form',
  templateUrl: './funcionario-detail-form.component.html',
  styleUrls: ['./funcionario-detail-form.component.css']
})
export class FuncionarioDetailFormComponent implements OnInit {

  constructor(
    private funcionarioFormService: FuncionarioFormService
  ) { }

  ngOnInit() {
  }

  save(f) {
  }

}
