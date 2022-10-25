import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { GigEditComponent } from 'src/app/modals/gig-edit/gig-edit.component';
import { Gig } from 'src/app/_models/Gig';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { GigsService } from 'src/app/_services/gigs.service';

@Component({
  selector: 'app-gig-detail',
  templateUrl: './gig-detail.component.html',
  styleUrls: ['./gig-detail.component.css']
})
export class GigDetailComponent implements OnInit {
  gig: Gig;
  user: User;
  bsModalRef :BsModalRef;

  constructor(private accountService: AccountService, private gigService: GigsService, private route: ActivatedRoute, private toastr: ToastrService, private router: Router) { 
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.gig = data.gig;
      localStorage.setItem('currentGig', JSON.stringify(this.gig));
      console.log(this.gig.username);
    })
  }

  deleteGig() {
    if (confirm("Are you sure you want to delete this gig?")) {
      this.gigService.deleteGig(parseInt(this.route.snapshot.paramMap.get('id'))).subscribe(response => {
        this.router.navigateByUrl('/gigs');
        this.toastr.success('Gig deleted successfully');
        //window.location.reload();
       }, error => {
        console.log(error);
       })
    }    
  }
}
