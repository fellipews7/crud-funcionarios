import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FuncionarioDetailFormComponent } from './funcionario-detail-form.component';

describe('FuncionarioDetailFormComponent', () => {
  let component: FuncionarioDetailFormComponent;
  let fixture: ComponentFixture<FuncionarioDetailFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FuncionarioDetailFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FuncionarioDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
