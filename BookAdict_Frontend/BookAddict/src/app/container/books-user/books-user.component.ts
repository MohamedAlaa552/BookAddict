import { Component, OnDestroy, OnInit } from '@angular/core';
import { BookApis } from '../../server/BookApis.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryApisService } from '../../server/CategoryApis/CategotyApis.service';
import { BookUserComponent } from './book-user/book-user.component';
import { CartApis } from '../../server/CartApi.Services';
import { CartItem } from '../../Models/CartItem';
import { AuthApis } from '../../server/Auth.services';
import { Subscription } from 'rxjs';
import { User } from '../../Models/User';
import { CartServices } from '../../header/cart/cart-services.service';

@Component({
  selector: 'books-user',
  templateUrl: './books-user.component.html',
  styleUrl: './books-user.component.css'
})
export class BooksUserComponent implements OnInit , OnDestroy {
isLoading:boolean = true;
books:any
user:User
cartItems:CartItem[] = []
error:HttpErrorResponse
sortList:string[] = ['latest','price']
sortedOn:string
choosedCategory:string = ""
allCategories:any[]
userSup:Subscription;

constructor(private bookApi :BookApis,
  private categoryApi: CategoryApisService,
  private authApi:AuthApis,
  private cartServices:CartServices,
  private route:ActivatedRoute ,
  private router :Router){}

host = this.bookApi.localhost
ngOnInit(){
  this.userSup = this.authApi.user.subscribe({
    next: data => this.user = data,
  })
this.GetAllBooks()
  this.sortedOn = this.route.snapshot.queryParams["sortby"] ?? ""
  this.categoryApi.getAllCategories().subscribe({
    next : res =>{
      this.allCategories = res
    },
    error: (err : HttpErrorResponse) =>{
      this.isLoading = false;
    }
  })
}
addToCart(event:Event,book,quantity=1){
  event.stopPropagation()
  this.cartServices.addToCart(book,quantity)
}
sortPage(sort){
  this.router.navigate(["/books"],{queryParams:{"sortby" : sort.value}})
  this.GetAllBooks(sort.value)
}

chooseCategory(category){
  if(category.value == "all")
    this.GetAllBooks();
  else {
    this.router.navigate(["/books"],{queryParams:{"category" : category.value}})
    this.GetAllBooks(null,category.value)
  }
}

search(searchform){
  if(searchform.value.search != null && searchform.value.search != ""){
    this.isLoading = true
    this.router.navigate(["/books"],{queryParams:{"searchtext" : searchform.value.search}})
    this.bookApi.SearchBooks(searchform.value.search).subscribe(response => {
      this.books = response;
      this.isLoading = false;
    })
  }
  else{
    this.isLoading = true
    this.router.navigate(["/books"])
    this.GetAllBooks()
  }
}
NavigateBook(book){
  this.router.navigate([`./books/${book.id}`]);
}

GetAllBooks(sortBy?:string , category?:string){
  this.isLoading = true
  this.bookApi.GetBooks(sortBy,category).subscribe({
    next: response => {
      this.books = response;
      this.isLoading = false
    },
    error: (err : HttpErrorResponse) =>{
      this.error = err.error;
      this.isLoading = false;
    }
  })
}

ngOnDestroy(): void {
  this.userSup.unsubscribe()
}
}
