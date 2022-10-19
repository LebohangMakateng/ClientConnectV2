import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
      @ViewChild('editForm') editForm: NgForm
      //member: Member;
      user: User;
      @HostListener('window:beforeunload', ['$event]']) unloadNotification($event: any) {
        if (this.editForm.dirty) {
          $event.returnValue = true;
        }
      }

      constructor(private accountService: AccountService, private memberService: MembersService,
        private toastr: ToastrService) { 
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
    }


    ngOnInit(): void {
      this.loadMember();
    }

    loadMember() {
      this.memberService.getMember(this.user.username).subscribe(member => {
        this.user = member;
      });
    }

    updateMember() {
      this.memberService.updateMember(this.user).subscribe(() =>{
        this.toastr.success('Profile updated succesfully');
        this.editForm.reset(this.user)
      })
    }

}
