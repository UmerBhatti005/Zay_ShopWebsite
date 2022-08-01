import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalfrAddComponent } from './modalfr-add.component';

describe('ModalfrAddComponent', () => {
  let component: ModalfrAddComponent;
  let fixture: ComponentFixture<ModalfrAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalfrAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalfrAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
