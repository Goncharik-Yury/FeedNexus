import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RssFeedListComponent } from './rss-feed-list.component';

describe('RssFeedListComponent', () => {
  let component: RssFeedListComponent;
  let fixture: ComponentFixture<RssFeedListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RssFeedListComponent]
    });
    fixture = TestBed.createComponent(RssFeedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
