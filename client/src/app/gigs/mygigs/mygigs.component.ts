import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { GigAddComponent } from 'src/app/modals/gig-add/gig-add.component';
import { Gig } from 'src/app/_models/Gig';
import { Pagination } from 'src/app/_models/pagination';
import { GigsService } from 'src/app/_services/gigs.service';

@Component({
  selector: 'app-gig-list',
  templateUrl: './mygigs.component.html',
  styleUrls: ['./mygigs.component.css']
})
export class MygigsComponent implements OnInit {
  gigs: Gig[];
  gig: Gig;
  bsModalRef: BsModalRef;
  pagination: Pagination;
  pageNumber = 1;
  pageSize = 10;
  filter = false;
  gigtitle = "plumber";

  constructor(private gigService: GigsService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.loadGigs();
  }

  loadGigs() {
    this.gigService.getGigs(this.pageNumber, this.pageSize, this.filter).subscribe(response => {
      this.gigs = response.result;
      this.pagination = response.pagination;
    })
  };

  searchGigs() {
    this.gigService.searchGigs(this.pageNumber, this.pageSize, this.gigtitle).subscribe(response => {
      this.gigs = response.result;
      this.pagination = response.pagination;
    })
  }

  pageChanged(event: any) {
    this.pageNumber = event.page;
    this.loadGigs();
  }

  openAddModal() {
    const config = {
      class: 'modal-dialog-centered modal-lg'
    }
    this.bsModalRef = this.modalService.show(GigAddComponent, config);
  }
}
