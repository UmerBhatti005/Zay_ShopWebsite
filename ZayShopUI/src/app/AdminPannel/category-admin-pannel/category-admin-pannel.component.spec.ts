import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryAdminPannelComponent } from './category-admin-pannel.component';

describe('CategoryAdminPannelComponent', () => {
  let component: CategoryAdminPannelComponent;
  let fixture: ComponentFixture<CategoryAdminPannelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryAdminPannelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryAdminPannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
