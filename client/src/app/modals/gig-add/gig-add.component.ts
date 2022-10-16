import { DatePipe, DecimalPipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Gig } from 'src/app/_models/Gig';
import { GigsService } from 'src/app/_services/gigs.service';

@Component({
  selector: 'app-gig-add',
  templateUrl: './gig-add.component.html',
  styleUrls: ['./gig-add.component.css']
})
export class GigAddComponent implements OnInit {
  addForm: FormGroup;


  constructor(public bsModalRef: BsModalRef, private gigService: GigsService, 
    private fb: FormBuilder, private toastr: ToastrService, public decimalPipe: DecimalPipe, private router: Router) { }

  ngOnInit(): void {
    this.initialiseForm();
  }

  initialiseForm() {
      this.addForm = this.fb.group({
      date: [new Date, Validators.required],
      description: ['', Validators.required],
      title: ['', Validators.required],
      taskrate: [Validators.required, Validators.min(1)],
      location: ['', Validators.required],
      username: ['', Validators.required],
      expertise: ['', Validators.required],
    })
  }

  addGig() {
     this.gigService.addGig(this.addForm.value).subscribe(response => {
      this.bsModalRef.hide();
      window.location.reload();
     }, error => {
      console.log(error);
     })
  }
}
