import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Auto, Korisnici, Lokacija} from '../shared/putni-nalog.model';
import { PutniNalogService } from '../shared/putni-nalog.service';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap'
import {NgForm} from '@angular/forms';

@Component({
  templateUrl: 'admin.component.html',
  providers: [NgbModalConfig, NgbModal]
})

export class AdminComponent implements OnInit {
  constructor(public service: PutniNalogService,
    private toastr: ToastrService,
    config: NgbModalConfig,
    private modalService: NgbModal) {
    config.backdrop = 'static';
    config.keyboard = false;
  }

  open(any: any) {
    this.modalService.open(any);
  }

  openPutLokacija(any:any, put:any){
    this.modalService.open(any);
    this.populateFormLokacija(put);
  }

  openPutPutnik(any:any, put:any){
    this.modalService.open(any);
    this.populateFormKorisnici(put);
  }

  openPutAuto(any:any, put:any){
    this.modalService.open(any);
    this.populateFormAuto(put);
  }

  

  ngOnInit(): void {
    this.service.refreshListLokacija();
    this.service.refreshListPutnik();
    this.service.refreshListAuto();
  }

  populateFormLokacija(selectedRecord: Lokacija) {
    this.service.formDataLokacija = Object.assign({}, selectedRecord);
  }

  populateFormKorisnici(selectedRecord: Korisnici) {
    this.service.formDataKorisnici = Object.assign({}, selectedRecord);
  }

  populateFormAuto(selectedRecord: Auto) {
    this.service.formDataAuto = Object.assign({}, selectedRecord);
  }


  onDeleteLokacija(id: number) {
    if (confirm('Jeste li sigurni da želite obrisati lokaciju?')) {
      this.service.deleteLokacija(id)
        .subscribe(
          res => {
            this.service.refreshListLokacija();
            this.toastr.error("Uspješno obrisano", 'Lokacija');
          },
          err => { console.log(err) }
        )
    }
  }

  onDeletePutnik(id: number) {
    if (confirm('Jeste li sigurni da želite obrisati putnika?')) {
      this.service.deletePutnik(id)
        .subscribe(
          res => {
            this.service.refreshListPutnik();
            this.toastr.error("Uspješno obrisano", 'Putnik');
          },
          err => { console.log(err) }
        )
    }
  }

  onDeleteAuto(id: number) {
    if (confirm('Jeste li sigurni da želite obrisati Automobil?')) {
      this.service.deleteAuto(id)
        .subscribe(
          res => {
            this.service.refreshListAuto();
            this.toastr.error("Uspješno obrisano", 'Automobil');
          },
          err => { console.log(err) }
        )
    }
  }


  onSubmitLokacija(form:NgForm){
    if(this.service.formDataLokacija.idLokacija==0)
      this.insertRecordLokacija(form);
    else
      this.updateRecordLokacija(form);
  }

  insertRecordLokacija(form:NgForm){
    this.service.postLokacija().subscribe(
      res =>{
          this.resetFormLokacija(form);
          this.service.refreshListLokacija();
          this.toastr.success('Uspješan unos','Lokacija')
      },
      err=>{
        console.log(err);
      }
    );
  }

  updateRecordLokacija(form:NgForm){
    this.service.putLokacija().subscribe(
      res =>{
          this.resetFormLokacija(form);
          this.service.refreshListLokacija();
          this.toastr.info('Uspješno uređeno','Lokacija')
      },
      err=>{
        console.log(err);
      }
    );
  }

  resetFormLokacija(form:NgForm){
    form.form.reset();
    this.service.formDataLokacija = new Lokacija();
  }




  onSubmitPutnik(form:NgForm){
    if(this.service.formDataKorisnici.idKorisnik==0)
      this.insertRecordPutnik(form);
    else
      this.updateRecordPutnik(form);
  }

  insertRecordPutnik(form:NgForm){
    this.service.postPutnik().subscribe(
      res =>{
          this.resetFormPutnik(form);
          this.service.refreshListPutnik();
          this.toastr.success('Uspješan unos','Putnik')
      },
      err=>{
        console.log(err);
      }
    );
  }

  updateRecordPutnik(form:NgForm){
    this.service.putPutnik().subscribe(
      res =>{
          this.resetFormPutnik(form);
          this.service.refreshListPutnik();
          this.toastr.info('Uspješno uređeno','Putnik')
      },
      err=>{
        console.log(err);
      }
    );
  }

  resetFormPutnik(form:NgForm){
    form.form.reset();
    this.service.formDataKorisnici = new Korisnici();
  }
  



  onSubmitAuto(form:NgForm){
    if(this.service.formDataAuto.idAuto==0)
      this.insertRecordAuto(form);
    else
      this.updateRecordAuto(form);
  }

  insertRecordAuto(form:NgForm){
    this.service.postAuto().subscribe(
      res =>{
          this.resetFormAuto(form);
          this.service.refreshListAuto();
          this.toastr.success('Uspješan unos','Automobil')
      },
      err=>{
        console.log(err);
      }
    );
  }

  updateRecordAuto(form:NgForm){
    this.service.putAuto().subscribe(
      res =>{
          this.resetFormAuto(form);
          this.service.refreshListAuto();
          this.toastr.info('Uspješno uređeno','Automobil')
      },
      err=>{
        console.log(err);
      }
    );
  }

  resetFormAuto(form:NgForm){
    form.form.reset();
    this.service.formDataAuto = new Auto();
  }
}
