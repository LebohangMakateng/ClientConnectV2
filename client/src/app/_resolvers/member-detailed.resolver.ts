import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { MembersService } from '../_services/members.service';

@Injectable({
    providedIn: 'root'
})
export class MemberDetailedResolver implements Resolve<User> {

    constructor(private memberService: MembersService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User> {
        return this.memberService.getMember(route.paramMap.get('username'));
    }
}