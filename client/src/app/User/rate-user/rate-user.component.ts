import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Pagination } from 'src/app/_models/pagination';
import { Rating } from 'src/app/_models/rating';
import { User } from 'src/app/_models/user';
import { MembersService } from 'src/app/_services/members.service';
import { RatingService } from 'src/app/_services/rating.service';

@Component({
  selector: 'app-rate-user',
  templateUrl: './rate-user.component.html',
  styleUrls: ['./rate-user.component.css']
})
export class RateUserComponent implements OnInit {
  @ViewChild('ratingForm') ratingForm: NgForm
  @Input() ratings: Rating[] = [];
  @Input() username = "kagiso";
  ratingContent: string;
  loading = false;
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination;
  container = 'Unread';
  member: User;


  constructor( private route: ActivatedRoute, private ratingService: RatingService) { }

  ngOnInit(): void {
    //this.route.data.subscribe(data => {
     // this.member = data.member;
    //})
    this.loadRatings();
  }

  sendRating() {
    this.ratingService.sendRating(this.username, this.ratingContent).subscribe(rating => {
      this.ratings.push(rating);
      //this.ratingForm.reset();
    })
  }

  loadRatings() {
    this.loading = true;
    this.ratingService.getRatings(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.ratings = response.result;
      this.pagination = response.pagination;
      this.loading = false;
    })
  }

  loadRatingThread() {
    this.ratingService.getRatingThread(this.username).subscribe(ratings => {
      this.ratings = ratings;
    })
  }



}
