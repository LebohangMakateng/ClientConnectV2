import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Gig } from '../_models/Gig';
import { PaginatedResult } from '../_models/pagination';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class GigsService {
  baseUrl = environment.apiUrl;
  public gig: Gig;
  paginatedResult: PaginatedResult<Gig[]> = new PaginatedResult<Gig[]>();

  constructor(private http: HttpClient) { }

  getGigs(pageNumber: number, pageSize: number, filter: boolean) {
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('filter', filter);

    return getPaginatedResult<Partial<Gig[]>>(this.baseUrl + 'gigs/GetGigs', params, this.http);
  }

  getAllGigs(pageNumber: number, pageSize: number, filter: boolean) {
    let params = getPaginationHeaders(pageNumber, pageSize);

    //params = params.append('gigtitle', gigtitle);

    params = params.append('filter', filter);

    return getPaginatedResult<Partial<Gig[]>>(this.baseUrl + 'gigs/GetAllGigs', params, this.http);
  }

  searchGigs(pageNumber: number, pageSize: number, gigtitle: string)
  {
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('gigtitle', gigtitle);

    return getPaginatedResult<Partial<Gig[]>>(this.baseUrl + 'gigs/SearchGigs', params, this.http);
  }

  /*getGigsLocation(location: string, pageNumber: number, pageSize: number, filter: boolean){
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('filter', filter);

    return getPaginatedResult<Partial<Gig[]>>(this.baseUrl + 'gigs', params, this.http);
  }

  getGigsExpertise(expertise: string, pageNumber: number, pageSize: number, filter: boolean){
    let params = getPaginationHeaders(pageNumber, pageSize);

    params = params.append('filter', filter);

    return getPaginatedResult<Partial<Gig[]>>(this.baseUrl + 'gigs', params, this.http);
  }*/

  getGig(id: number) {
    return this.http.get<Gig>(this.baseUrl + 'gigs/' + id)
  }

  updateGig(id, gig: Gig) {
    return this.http.put(this.baseUrl + 'gigs/' + id, gig);
  }

  addGig(gig: Gig) {
    return this.http.post<Gig>(this.baseUrl + 'gigs/', gig);
  }

  deleteGig(id: number) {
    return this.http.delete<Gig>(this.baseUrl + 'gigs/' + id);
  }
}
