import { Button, CardActions, CardContent, Chip, Typography } from '@mui/material'
import SentimentDissatisfiedIcon from '@mui/icons-material/SentimentDissatisfied';
import Card from '@mui/material/Card'

type Props = {
    taskitem: TaskItem
    cancelTaskItem: () => void
    openForm: (id?: string) => void
}

export default function TaskDetail({ taskitem, cancelTaskItem, openForm }: Props) {
    return (
        <Card sx={{ borderRadius: 2, boxShadow: "0 2px 5px rgba(0, 0, 0, 0.4)" }}>
            <CardContent>
                <div
                    style={{
                        display: "flex",
                        justifyContent: "space-between",
                        alignItems: "center",
                        marginBottom: "8px"
                    }}
                >
                    <Typography variant="h6" component="h6">
                        {taskitem.title}
                    </Typography>

                    <div style={{
                        color: taskitem.iscompleted ? "#388e3c" : "#ef6c00",
                        fontSize: "0.7em",
                        display: "flex",
                        alignItems: "center"
                    }}>
                        {taskitem.iscompleted ? "Completed" : "Pending"}
                        <SentimentDissatisfiedIcon sx={{ marginLeft: 1 }} />
                    </div>

                </div>
                <Typography variant="subtitle1" sx={{ color: '#424242', fontSize: '0.7em' }}>
                    {new Date(taskitem.dateAdded).toLocaleDateString()}
                </Typography>
                <Typography variant="body2" color="text.secondary" sx={{ mb: 1 }}>
                    {taskitem.description}
                </Typography>
            </CardContent>
            <CardActions sx={{ display: "flex", justifyContent: "flex-start", padding: 2 }}>
                <Button color="primary" onClick={() => openForm(taskitem.id)}>
                    Edit
                </Button>
                <Button color="inherit" onClick={cancelTaskItem}>
                    Cancel
                </Button>
            </CardActions>
        </Card>
    )
}
