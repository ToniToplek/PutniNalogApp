import { Component, NgModule, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PutniNalog } from '../shared/putni-nalog.model';
import { PutniNalogService } from '../shared/putni-nalog.service';
import { NgForm, ReactiveFormsModule } from '@angular/forms';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap'

@Component({
  selector: 'app-putni-nalog',
  templateUrl: './putni-nalog.component.html',
  styles: [
  ]
})


export class PutniNalogComponent implements OnInit {

  constructor(public service: PutniNalogService,
    private toastr: ToastrService,
    config: NgbModalConfig,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.service.refreshListLokacija();
    this.service.refreshListPutnik();
    this.service.refreshListAuto();
    this.service.refreshListKorisniciNalog();
  }

  open(any: any) {
    this.modalService.open(any);
  }

  populateForm(selectedRecord: PutniNalog) {
    this.service.formData = Object.assign({}, selectedRecord);
    let a: any;
    for (a of this.service.listKorisniciNalog) {
      if (this.service.formData.idPutniNalog == a["idPutniNalog"]) {
        this.service.formDataKorisniciNalog.idKorisnik = a["idKorisnik"]
        console.log(this.service.formDataKorisniciNalog.idKorisnik)
      }
    }
  }

  onDelete(id: number) {
    if (confirm('Jeste li sigurni da želite obrisati putni nalog?')) {
      this.service.deletePutniNalog(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.error("Uspješno obrisano", 'Putni Nalog');
          },
          err => { console.log(err) }
        )
    }
  }

  onSubmit(form: NgForm) {

    if (this.service.formData.idPutniNalog == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postPutniNalog().subscribe(
      (res: any) => {

        if (res.hasOwnProperty('idPutniNalog')) {
          this.service.formDataKorisniciNalog.idPutniNalog = res['idPutniNalog'];
        }

        this.service.postKorisniciNalog().subscribe(
          res => {
            this.service.refreshListKorisniciNalog();
          },
          err => {
            console.log(err);
          }
        );

        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Uspješan unos', 'Putni Nalog');
      },
      err => {
        console.log(err);
      },
    );



  }

  updateRecord(form: NgForm) {
    this.service.putPutniNalog().subscribe(
      res => {
        let obj: any;
        for (obj of this.service.listKorisniciNalog) {
          if (this.service.formData.idPutniNalog == obj["idPutniNalog"]) {
            this.service.formDataKorisniciNalog.idKorisniciNalog = obj["idKorisniciNalog"];
            this.service.formDataKorisniciNalog.idPutniNalog=obj["idPutniNalog"];
            console.log(this.service.formDataKorisniciNalog.idKorisniciNalog);
          }
        }
        this.service.putKorisniciNalog().subscribe(
          res => {
            this.service.refreshListKorisniciNalog();
          },
          err => {
            console.log(err);
          }
        );

        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Uspješno uređeno', 'Putni Nalog')
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new PutniNalog();
  }

  resetForm1() {
    this.service.formData = new PutniNalog();
  }


  openAdminForm() {
    window.open('./admin-form.component.html', "_self");
  }
  div1: boolean = false;

  divShow() {
    if (this.div1 == true) {
      this.div1 = false
    } else
      this.div1 = true
  }
  divShow1() {
    this.div1 = true
  }
}
