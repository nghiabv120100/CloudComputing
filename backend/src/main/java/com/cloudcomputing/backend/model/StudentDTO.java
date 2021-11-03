package com.cloudcomputing.backend.model;

import javax.persistence.*;

@Entity
public class StudentDTO {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer mssv;
    @Column
    private String fullname;
    @Column
    private String classname;
    @Column
    private String sex;
    @Column
    private double gpa;

    public Integer getMssv() {
        return mssv;
    }

    public void setMssv(Integer mssv) {
        this.mssv = mssv;
    }

    public String getFullname() {
        return fullname;
    }

    public void setFullname(String fullname) {
        this.fullname = fullname;
    }

    public String getClassname() {
        return classname;
    }

    public void setClassname(String classname) {
        this.classname = classname;
    }

    public String getSex() {
        return sex;
    }

    public void setSex(String sex) {
        this.sex = sex;
    }

    public double getGpa() {
        return gpa;
    }

    public void setGpa(double gpa) {
        this.gpa = gpa;
    }
}
