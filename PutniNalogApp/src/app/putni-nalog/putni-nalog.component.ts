import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PutniNalog } from '../shared/putni-nalog.model';
import { PutniNalogService } from '../shared/putni-nalog.service';

@Component({
  selector: 'app-putni-nalog',
  templateUrl: './putni-nalog.component.html',
  styles: [
  ]
})
export class PutniNalogComponent implements OnInit {

  constructor(public service: PutniNalogService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:PutniNalog){
    this.service.formData = Object.assign({}, selectedRecord);

  }

  onDelete(id:number){
    if(confirm('Jeste li sigurni da želite obrisati putni nalog?'))
    {   
    this.service.deletePutniNalog(id)
    .subscribe(
      res=>{
        this.service.refreshList();
        this.toastr.error("Uspješno obrisano", 'Putni Nalog');
      },
      err=>{console.log(err)}
    )
    }    
  }
  


}
