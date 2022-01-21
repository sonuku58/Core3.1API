import { PipeTransform ,Pipe} from "@angular/core";

@Pipe({
    name:'nameFilter'
})

export class nameFilterPipe implements PipeTransform{
    transform(allStudent:any,nameSearch:string):any{
        if(!allStudent || !nameSearch){
            return allStudent;
        }
        return allStudent.filter((student: { firstName: string; }) => 
        student.firstName.toLowerCase().indexOf(nameSearch.toLowerCase()) !== -1);
    }
}