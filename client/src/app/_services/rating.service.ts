import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Rating } from '../_models/rating';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class RatingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRatings(pageNumber, pageSize, container) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append('Container', container);
    return getPaginatedResult<Rating[]>(this.baseUrl + 'ratings', params, this.http);
  }

  getRatingThread(username: string) {
    return this.http.get<Rating[]>(this.baseUrl + 'ratings/thread/' + username);
  }

  sendRating(username: string, content: string, score: number) {
    return this.http.post<Rating>(this.baseUrl + 'ratings', {recipientUsername: username, content, score})
  }

  deleteRating(id: number) {
    return this.http.delete(this.baseUrl + 'ratings/' + id);
  }
}