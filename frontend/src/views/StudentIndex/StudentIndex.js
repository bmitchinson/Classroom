import React, { Component } from 'react';
import axios from 'axios'

import { Grid, Typography, Button } from '@material-ui/core';

import Student from '../../components/Student/Student';

class StudentIndex extends Component {
    constructor(props) {
        super(props)
        this.state = {
            students: null
        }
        this.refreshStudentIndex = this.refreshStudentIndex.bind(this)
        this.addStudent = this.addStudent.bind(this)
    }

    // TODO: Loading
    componentDidMount(){
        this.refreshStudentIndex()
    }

    refreshStudentIndex(){
        fetch("http://localhost:5000/api/student")
        .then(res => res.json())
        .then(
            result => {
                this.setState({
                    students: result
                });
            },
            error => {
                console.log('error:', error)
            }
        );
    }

    addStudent(){
        axios({
            method: 'post',
            url: 'http://localhost:5000/api/student',
            data: {
                FirstName: "Ben",
                LastName: "Mitchinson",
                BirthDate: "2000-1-1T00:00:00"
            }
        }).then(function (response) {
            console.log('res', response);
            this.refreshStudentIndex()
        }.bind(this))
        .catch(function (error) {
            console.log('err', error);
        })
    }
    
    render() {
        const { students } = this.state

        return (
            <Grid container spacing={4} alignItems='center'>
                <Grid item xs={4}>
                    <Typography variant='h2'>
                        All Students
                    </Typography>
                </Grid>
                <div style={{flexGrow: 1}} />
                <Grid item xs={1}>
                    <Button 
                        color='primary' 
                        variant='contained'
                        onClick={this.addStudent}
                        >
                            New Student
                        </Button>
                </Grid>
                {students && students.map(student => 
                    <Grid key={student.studentId} item xs={12}>
                        <Student student={student} refreshIndex={this.refreshStudentIndex}/>
                    </Grid>
                )}
            </Grid>
        )
    }
}

export default StudentIndex