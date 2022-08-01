import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusAdminPannelComponent } from './status-admin-pannel.component';

describe('StatusAdminPannelComponent', () => {
  let component: StatusAdminPannelComponent;
  let fixture: ComponentFixture<StatusAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StatusAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StatusAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
