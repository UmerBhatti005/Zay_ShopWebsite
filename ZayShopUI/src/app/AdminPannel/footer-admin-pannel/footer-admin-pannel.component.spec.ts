import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FooterAdminPannelComponent } from './footer-admin-pannel.component';

describe('FooterAdminPannelComponent', () => {
  let component: FooterAdminPannelComponent;
  let fixture: ComponentFixture<FooterAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FooterAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FooterAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
