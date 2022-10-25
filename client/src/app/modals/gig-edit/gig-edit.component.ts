import { DatePipe } from '@angular/common';
import { Component, EventEmitter, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { Gig } from 'src/app/_models/Gig';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { GigsService } from 'src/app/_services/gigs.service';

@Component({
  selector: 'app-gig-edit',
  templateUrl: './gig-edit.component.html',
  styleUrls: ['./gig-edit.component.css']
})
export class GigEditComponent implements OnInit {
  gig: Gig;
  id: number;
  editForm: FormGroup;
  formattedDate: string;
  use
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
    if(this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private gigService: GigsService, private toastr: ToastrService, private route: ActivatedRoute,
    private fb: FormBuilder, public datePipe: DatePipe) { 
  }

  ngOnInit(): void {
    this.loadGig();
  }


  initialiseForm() {
    this.editForm = this.fb.group({
    date: [this.formattedDate, Validators.required],
    description: [this.gig.description, Validators.required],
    hidegig: [this.gig.description, Validators.required],
    taskrate: [this.gig.taskrate, [Validators.required, Validators.min(1)]]
    
  })
  console.log("date: " + this.formattedDate)
}

  loadGig() {
    let currentGigId = JSON.parse(localStorage.getItem('currentGig'))?.id;
    this.gigService.getGig(currentGigId).subscribe(gig => {
      this.gig = gig;
      this.formattedDate = this.datePipe.transform((this.gig.date), 'dd-MMM-yyyy');
      this.initialiseForm();
    })
  }
  
  updateGig() {
    this.gigService.updateGig(this.gig.id, this.editForm.value).subscribe(() => {
      this.toastr.success('Gig updated successfully');
      this.loadGig();
      this.editForm.reset(this.gig)
    })    
  }
}
