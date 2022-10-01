import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { Gig } from '../_models/Gig';
import { GigsService } from '../_services/gigs.service';

@Injectable({
  providedIn: 'root'
})
export class GigResolverResolver implements Resolve<Gig> {
  constructor(private gigService: GigsService) {}
  resolve(route: ActivatedRouteSnapshot): Observable<Gig> {
    return this.gigService.getGig(parseInt(route.paramMap.get('id')));
  }
}
