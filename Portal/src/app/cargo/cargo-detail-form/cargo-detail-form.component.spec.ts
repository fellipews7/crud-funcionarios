import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CargoDetailFormComponent } from './cargo-detail-form.component';

describe('CargoDetailFormComponent', () => {
  let component: CargoDetailFormComponent;
  let fixture: ComponentFixture<CargoDetailFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CargoDetailFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CargoDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
