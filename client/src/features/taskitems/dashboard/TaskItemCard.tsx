import { Button, Card, CardActions, CardContent, Chip, Icon, Typography } from "@mui/material"
import SignalCellular1BarIcon from '@mui/icons-material/SignalCellular1Bar';

type Props = {
    taskitem: TaskItem
    selectTaskItem: (id: string) => void
}

export default function TaskItemCard({ taskitem, selectTaskItem }: Props) {
    return (
        <Card sx={{
            marginBottom: 1,
            borderRadius: 2,
            boxShadow: "0 2px 5px rgba(0, 0, 0, 0.4)",
            cursor: "pointer",
        }}
            onClick={() => selectTaskItem(taskitem.id)}
        >

            <div style={{ display: "flex", justifyContent: "space-between", padding: 10 }}>
                <Typography variant="h6" component="h6" sx={{ marginBottom: 1, color: '#140202' }}>
                    {taskitem.title}
                    <div style={{ color: '#424242', fontSize: '0.6em' }}>
                        Added on: {new Date(taskitem.dateAdded).toLocaleDateString()}
                    </div>
                </Typography>
                <div style={{
                    color: taskitem.iscompleted ? "#388e3c" : "#ef6c00",
                    display: "flex",
                    alignItems: "center"
                }}>
                    <div style={{ fontSize: "0.7em" }}> {taskitem.iscompleted ? "Completed" : "Pending"}</div>
                    <SignalCellular1BarIcon sx={{ color: taskitem.iscompleted ? "#388e3c" : "#ef6c00", fontSize: "1.5em" }} />
                </div>
            </div>
        </Card >
    )
}
