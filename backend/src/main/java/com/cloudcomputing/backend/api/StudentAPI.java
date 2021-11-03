package com.cloudcomputing.backend.api;

import com.cloudcomputing.backend.model.StudentDTO;
import com.cloudcomputing.backend.service.StudentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/student/")
public class StudentAPI {
    @Autowired
    private StudentService studentService;

    @PostMapping("add")
    public StudentDTO addStudent(@RequestBody StudentDTO student) {
        StudentDTO st= studentService.addStudent(student);
        return  st;
    }

    @GetMapping("getAll")
    public List<StudentDTO> getAllStudent() {
        List<StudentDTO> lstStudent = studentService.getAllStudent();
        return lstStudent.size() > 0 ? lstStudent : null;
    }

    @GetMapping("getById/{mssv}")
    public StudentDTO getStudentById(@PathVariable Integer mssv) {
        StudentDTO st= studentService.getStudentById(mssv);
        return  st;
    }
    @PutMapping("update")
    public StudentDTO updateStudent(@RequestBody StudentDTO student) {
        StudentDTO newStudent = studentService.updateStudent(student);
        return newStudent;
    }
}
