import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PutniNalogService } from 'src/app/shared/putni-nalog.service';
import { Korisnici, Lokacija, PutniNalog } from 'src/app/shared/putni-nalog.model';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-putni-nalog-form',
  templateUrl: './putni-nalog-form.component.html',
  styles: [
  ]
})



export class PutniNalogFormComponent implements OnInit {
  constructor(public service: PutniNalogService, 
    private toastr:ToastrService){ 
      
  }


  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.idPutniNalog==0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postPutniNalog().subscribe(
      res =>{
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Uspješan unos','Putni Nalog')
      },
      err=>{
        console.log(err);
      }
    );
  }

  updateRecord(form:NgForm){
    this.service.putPutniNalog().subscribe(
      res =>{
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.info('Uspješno uređeno','Putni Nalog')
      },
      err=>{
        console.log(err);
      }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new PutniNalog();
  }

  addPutnik(){
    var txtP=document.createElement('div');

    txtP.innerHTML = "<input class='form-control form-control-lg' placeholder='Ime' name='imeKorisnik' #imeKorisnik='ngModel' [(ngModel)]='service.formData.korisniciNalogs.korisnik.imeKorisnik'> <input class='form-control form-control-lg' placeholder='Prezime' name='prezimeKorisnik' #prezimeKorisnik='ngModel' [(ngModel)]='service.formData.korisniciNalogs.korisnik.prezimeKorisnik'>";
    document.getElementById("putnici")?.appendChild(txtP);
  }

  openAdminForm(){
    window.open('./admin-form.component.html', "_self");
  }

}
