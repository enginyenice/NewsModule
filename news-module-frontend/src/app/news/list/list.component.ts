import { Component, OnInit } from '@angular/core';
import { NewsService } from '../news.service';
import { NewsModel } from '../models/news-model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  public News: NewsModel[] = [];
  constructor(private newsService: NewsService) { }
  ngOnInit(): void {
    this.getAll();
  }
  getAll() {
    this.newsService.getAll().subscribe({
      next: (response) => {
        this.News = response;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  delete(id: number) {
    this.newsService.delete(id).subscribe({
      next: (response) => {
        this.getAll();
      },
      error: (error) => {
        console.log(error)
      }
    })
  }
}
