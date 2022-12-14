import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Message } from 'src/app/_models/message';
import { MembersService } from 'src/app/_services/members.service';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-user-messages',
  templateUrl: './user-messages.component.html',
  styleUrls: ['./user-messages.component.css']
})
export class UserMessagesComponent implements OnInit {
  @ViewChild('messageForm') messageForm: NgForm;
  @Input() messages: Message[] = [];
  @Input() username: string;
  messageContent: string;
  

  constructor(private messageService: MessageService,  private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.loadMessages();
  }

  sendMessage() {
    this.messageService.sendMessage(this.username, this.messageContent).subscribe(message => {
      this.toastr.success('Message sent');
      this.messages.push(message);
      this.messageForm.reset();
    })
  }

  loadMessages() {
    this.messageService.getMessageThread(this.username).subscribe(messages => {
      this.messages = messages;
    })
  }

}