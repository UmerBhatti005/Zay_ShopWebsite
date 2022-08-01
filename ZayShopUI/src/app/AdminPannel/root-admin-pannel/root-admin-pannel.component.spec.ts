import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RootAdminPannelComponent } from './root-admin-pannel.component';

describe('RootAdminPannelComponent', () => {
  let component: RootAdminPannelComponent;
  let fixture: ComponentFixture<RootAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RootAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RootAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
