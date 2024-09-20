import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface RssFeed {
  id: number;         // Добавь id
  title: string;
  url: string;       // Это поле url
  createdAt: string; // Или Date, если ты используешь объект даты
}

@Component({
  selector: 'app-rss-feed-list',
  templateUrl: './rss-feed-list.component.html',
  styleUrls: ['./rss-feed-list.component.scss']
})
export class RssFeedListComponent implements OnInit {
  feeds: RssFeed[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<RssFeed[]>('https://localhost:5001/api/RssFeed')
      .subscribe(data => {
        this.feeds = data;
      });
  }
}
