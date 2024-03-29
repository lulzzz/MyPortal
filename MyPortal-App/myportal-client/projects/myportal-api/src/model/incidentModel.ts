/**
 * MyPortal
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { AcademicYearModel } from './academicYearModel';
import { BehaviourOutcomeModel } from './behaviourOutcomeModel';
import { BehaviourStatusModel } from './behaviourStatusModel';
import { IncidentTypeModel } from './incidentTypeModel';
import { LocationModel } from './locationModel';
import { StudentModel } from './studentModel';
import { UserModel } from './userModel';

export interface IncidentModel { 
    id?: string;
    academicYearId?: string;
    behaviourTypeId: string;
    studentId?: string;
    locationId: string;
    recordedById?: string;
    outcomeId?: string;
    statusId: string;
    createdDate?: Date;
    comments?: string;
    points: number;
    deleted?: boolean;
    type?: IncidentTypeModel;
    location?: LocationModel;
    academicYear?: AcademicYearModel;
    recordedBy?: UserModel;
    student?: StudentModel;
    outcome?: BehaviourOutcomeModel;
    status?: BehaviourStatusModel;
}