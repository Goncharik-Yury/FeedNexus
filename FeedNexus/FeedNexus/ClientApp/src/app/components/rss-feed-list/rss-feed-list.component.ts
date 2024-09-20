import { Component, OnInit } from '@angular/core';
import { RssFeedService } from '../../services/rss-feed.service';

@Component({
  selector: 'app-rss-feed-list',
  templateUrl: './rss-feed-list.component.html',
  styleUrls: ['./rss-feed-list.component.scss']
})
export class RssFeedListComponent implements OnInit {
  rssFeeds: any[] = [];

  constructor(private rssFeedService: RssFeedService) {}

  ngOnInit(): void {
    this.getRssFeeds();
  }

  getRssFeeds(): void {
    this.rssFeedService.getRssFeeds().subscribe((data) => {
      this.rssFeeds = data;
    });
  }
}
