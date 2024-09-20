import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RssFeedService {
  private apiUrl = 'http://localhost:5001/api/rssfeeds';

  constructor(private http: HttpClient) {}

  getRssFeeds(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
