import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideNavbarAdminPannelComponent } from './side-navbar-admin-pannel.component';

describe('SideNavbarAdminPannelComponent', () => {
  let component: SideNavbarAdminPannelComponent;
  let fixture: ComponentFixture<SideNavbarAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SideNavbarAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SideNavbarAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
