import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersAdminPannelComponent } from './users-admin-pannel.component';

describe('UsersAdminPannelComponent', () => {
  let component: UsersAdminPannelComponent;
  let fixture: ComponentFixture<UsersAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
