
$res = 0.0
$NUM = 100

for ($i = 0; $i -lt $NUM; $i++) {
     $res += (curl -X GET -w "%{time_total}" -o NUL http://localhost:50445/ 2> $null)
}
echo ($res / $NUM  / 1000)